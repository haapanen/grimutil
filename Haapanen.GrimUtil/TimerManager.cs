using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Haapanen.GrimUtil.Ui
{
    public class TimerManager
    {
        private Dictionary<string, Stopwatch> _timers = new Dictionary<string, Stopwatch>();

        #region Public API

        public void StartTimer(string run)
        {
            AddTimerIfNotExist(run);

            if (_timers[run].IsRunning)
            {
                return;
            }
            _timers[run].Start();
        }

        private void AddTimerIfNotExist(string run)
        {
            if (!_timers.ContainsKey(run))
            {
                _timers[run] = new Stopwatch();
            }
        }

        public void StopTimer(string run)
        {
            if (!_timers.ContainsKey(run))
            {
                return;
            }

            _timers[run].Stop();
        }

        public TimeSpan GetDuration(string run)
        {
            if (!_timers.ContainsKey(run))
            {
                return TimeSpan.Zero;
            }

            return _timers[run].Elapsed;
        }

        public void ResetTimer(string run)
        {
            if (!_timers.ContainsKey(run))
            {
                return;
            }

            _timers[run].Reset();
        }

        #endregion
    }
}
