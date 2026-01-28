using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.src.Common
{
    /// <summary>
    /// Ng?n ch?n vi?c click nhi?u l?n vào button trong th?i gian ng?n
    /// </summary>
    public static class ClickGuard
    {
        private static readonly ConcurrentDictionary<string, DateTime> _lastClickTimes = new();
        private static readonly TimeSpan _debounceInterval = TimeSpan.FromMilliseconds(500);

        /// <summary>
        /// Ch?y action m?t l?n duy nh?t, ng?n ch?n click liên t?c
        /// </summary>
        /// <param name="key">Key ??nh danh (th??ng là tên button ho?c action)</param>
        /// <param name="action">Action c?n th?c thi</param>
        /// <param name="sourceButton">Button ngu?n (tùy ch?n) ?? disable trong khi x? lý</param>
        public static async Task RunOnceAsync(string key, Func<Task> action, Button? sourceButton = null)
        {
            DateTime now = DateTime.UtcNow;

            // Ki?m tra th?i gian click cu?i cùng
            if (_lastClickTimes.TryGetValue(key, out DateTime lastClick))
            {
                if (now - lastClick < _debounceInterval)
                {
                    System.Diagnostics.Debug.WriteLine($"[ClickGuard] Blocked rapid click on '{key}'");
                    return;
                }
            }

            // C?p nh?t th?i gian click
            _lastClickTimes[key] = now;

            // Disable button t?m th?i n?u có
            bool wasEnabled = sourceButton?.Enabled ?? false;
            if (sourceButton != null)
            {
                sourceButton.Enabled = false;
            }

            try
            {
                await action();
            }
            finally
            {
                // Re-enable button sau khi xong
                if (sourceButton != null && wasEnabled)
                {
                    sourceButton.Enabled = true;
                }

                // Cleanup old entries (optional)
                CleanupOldEntries();
            }
        }

        /// <summary>
        /// D?n d?p các entry c? ?? tránh memory leak
        /// </summary>
        private static void CleanupOldEntries()
        {
            DateTime threshold = DateTime.UtcNow.AddMinutes(-5);
            
            foreach (var kvp in _lastClickTimes)
            {
                if (kvp.Value < threshold)
                {
                    _lastClickTimes.TryRemove(kvp.Key, out _);
                }
            }
        }
    }
}
