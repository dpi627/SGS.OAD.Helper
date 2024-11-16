using System.Reflection;

namespace SGS.OAD.Helper; // 命名空間與專案名稱相同，引用時候比較簡單

/// <summary>
/// 取得應用程式版本，支援 ClickOnce 部署
/// </summary>
public class VersionHelper
{
    private static readonly string? _isClickOnce = Environment.GetEnvironmentVariable("ClickOnce_IsNetworkDeployed");
    private static readonly string? _clickOnceVersion = Environment.GetEnvironmentVariable("ClickOnce_CurrentVersion");
    private static readonly string _defaultVersion = "0.0.0.0";

    /// <summary>
    /// 取得目前應用程式版本
    /// </summary>
    public static string CurrentVersion => GetApplicationVersion();

    private static string GetApplicationVersion()
    {
        try
        {
            // 判斷是否為 ClickOnce 部署，如是回傳其版本
            if (!string.IsNullOrEmpty(_isClickOnce) && bool.Parse(_isClickOnce))
                return _clickOnceVersion ?? _defaultVersion;

            // 使用 GetEntryAssembly 獲取主程式
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                var version = entryAssembly.GetName().Version;
                return version?.ToString() ?? _defaultVersion;
            }

            return _defaultVersion;
        }
        catch (Exception)
        {
            return _defaultVersion;
        }
    }
}
