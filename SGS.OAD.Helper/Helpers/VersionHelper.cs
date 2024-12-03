using System.Reflection;

#if NETFRAMEWORK
using System.Deployment.Application;
#endif

namespace SGS.OAD.Helper; // 命名空間與專案名稱相同，引用時候比較簡單

/// <summary>
/// 取得應用程式版本，支援 ClickOnce 部署
/// </summary>
public static class VersionHelper
{
    private static readonly string _defaultVersion = "0.0.0.0";

    /// <summary>
    /// 取得目前應用程式版本
    /// </summary>
    public static string CurrentVersion => GetApplicationVersion();

    private static string GetApplicationVersion()
    {
#if NETFRAMEWORK
        return GetApplicationVersionNetFramework();
#elif NET6_0_OR_GREATER
        return GetApplicationVersionNetCore();
#else
        return _defaultVersion;
#endif
    }

#if NET6_0_OR_GREATER
    /// <summary>
    /// 取得目前應用程式版本 (.NET 6+)
    /// </summary>
    /// <returns></returns>
    private static string GetApplicationVersionNetCore()
    {
        try
        {
            string? _isClickOnce = Environment.GetEnvironmentVariable("ClickOnce_IsNetworkDeployed");
            string? _clickOnceVersion = Environment.GetEnvironmentVariable("ClickOnce_CurrentVersion");

            // 判斷是否為 ClickOnce 部署，如是回傳其版本
            if (!string.IsNullOrEmpty(_isClickOnce) && bool.Parse(_isClickOnce))
                return _clickOnceVersion ?? _defaultVersion;
            else
                return GetAssemblyVersion();
        }
        catch
        {
            return _defaultVersion;
        }
    }
#endif

    /// <summary>
    /// 取得目前應用程式 Assembly 版本
    /// </summary>
    /// <returns></returns>
    private static string GetAssemblyVersion()
    {
        try
        {
            // 使用 GetEntryAssembly 獲取主程式
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                var version = entryAssembly.GetName().Version;
                return version?.ToString() ?? _defaultVersion;
            }
            return _defaultVersion;
        }
        catch
        {
            return _defaultVersion;
        }
    }

#if NETFRAMEWORK
    /// <summary>
    /// 取得目前應用程式版本 (.NET Framework 4.7, 4.8)
    /// </summary>
    /// <returns></returns>
    private static string GetApplicationVersionNetFramework()
    {
        try
        {
            // 使用 ApplicationDeployment 檢查是否為 ClickOnce 部署
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                var deployment = ApplicationDeployment.CurrentDeployment;
                return deployment.CurrentVersion.ToString();
            }
            else
            {
                return GetAssemblyVersion() ?? _defaultVersion;
            }
        }
        catch
        {
            return _defaultVersion;
        }
    }
#endif
}
