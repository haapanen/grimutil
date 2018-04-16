using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Haapanen.GrimUtil.Ui.WinApi
{
    public class KeyboardHook
    {
        private bool _hooked = false;
        private LowLevelKeyboardProc _proc;
        private IntPtr _hookId = IntPtr.Zero;
        private Dictionary<Keys, List<HookCallbacks>> _hooks = new Dictionary<Keys, List<HookCallbacks>>();

        #region Public API

        /// <summary>
        /// Adds a hook to the keyboard hook chain
        /// </summary>
        public void Hook()
        {
            if (_hooked)
            {
                throw new InvalidOperationException($"{nameof(KeyboardHook.Hook)} called more than once.");
            }
            _proc = HookCallback;
            using (var process = Process.GetCurrentProcess())
            using (var module = process.MainModule)
            {
                _hookId = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, GetModuleHandle(module.ModuleName), 0);
            }

            _hooked = true;
        }

        /// <summary>
        /// Removes the hook from the keyboard hook chain
        /// </summary>
        public void Unhook()
        {
            if (!_hooked)
            {
                throw new InvalidOperationException($"{nameof(KeyboardHook.Unhook)} called before hooking.");
            }
            UnhookWindowsHookEx(_hookId);
            _hooked = false;
        }

        /// <summary>
        /// Hooks the specified keypress and call the specified callbacks when keypress occurs
        /// </summary>
        /// <param name="key"></param>
        /// <param name="callbacks"></param>
        public void SetKeyboardHook(Keys key, HookCallbacks callbacks)
        {
            if (!_hooks.ContainsKey(key))
            {
                _hooks.Add(key, new List<HookCallbacks>());
            }

            _hooks[key].Add(callbacks);
        }

        /// <summary>
        /// Removes the specified callbacks from the specified key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="callbacks"></param>
        public void RemoveKeyboardHook(Keys key, HookCallbacks callbacks)
        {
            if (_hooks.ContainsKey(key))
            {
                _hooks[key].Remove(callbacks);
            }
        }

        /// <summary>
        /// Removes all keyboard callbacks
        /// </summary>
        public void RemoveKeyboardHooks()
        {
            _hooks.Clear();
        }

        #endregion

        #region Internal API

        /// <summary>
        /// An event occurred, react to it if it's WM_KEYDOWN/WM_KEYUP
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var key = (Keys)Marshal.ReadInt32(lParam);
                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    if (_hooks.ContainsKey(key))
                    {
                        foreach (var actions in _hooks[key])
                        {
                            actions.OnKeyDown?.Invoke();
                        }
                    }
                }
                else if (wParam == (IntPtr)WM_KEYUP)
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

        #endregion

        #region WinApi

        // https://stackoverflow.com/questions/604410/global-keyboard-capture-in-c-sharp-application
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

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

        #endregion
    }
}
