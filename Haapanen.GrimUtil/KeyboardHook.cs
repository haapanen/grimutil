using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Haapanen.GrimUtil.Ui
{
    public class KeyboardHook
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private LowLevelKeyboardProc _proc;
        private IntPtr _hookId = IntPtr.Zero;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private Dictionary<Keys, List<HookCallbacks>> _hooks = new Dictionary<Keys, List<HookCallbacks>>();

        public void Hook()
        {
            _proc = HookCallback;
            using (var process = Process.GetCurrentProcess())
            using (var module = process.MainModule)
            {
                _hookId = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, GetModuleHandle(module.ModuleName), 0);
            }
        }

        public void Unhook()
        {
            UnhookWindowsHookEx(_hookId);
        }

        public void SetKeyboardHook(Keys key, HookCallbacks callbacks)
        {
            if (!_hooks.ContainsKey(key))
            {
                _hooks.Add(key, new List<HookCallbacks>());
            }

            _hooks[key].Add(callbacks);
        }

        public void RemoveKeyboardHook(Keys key, HookCallbacks callbacks)
        {
            if (_hooks.ContainsKey(key))
            {
                _hooks[key].Remove(callbacks);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var key = (Keys)Marshal.ReadInt32(lParam);
                if (wParam == (IntPtr) WM_KEYDOWN)
                {
                    if (_hooks.ContainsKey(key))
                    {
                        foreach (var actions in _hooks[key])
                        {
                            actions.OnKeyDown?.Invoke();
                        }
                    }
                } else if (wParam == (IntPtr) WM_KEYUP)
                {
                    if (_hooks.ContainsKey(key))
                    {
                        foreach (var actions in _hooks[key])
                        {
                            actions.OnKeyUp?.Invoke();
                        }
                    }
                }
            }
            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        public void RemoveKeyboardHooks()
        {
            _hooks.Clear();
        }
    }
}
