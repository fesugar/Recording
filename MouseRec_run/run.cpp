#pragma region  检测注册表
/*----------------------------------------------------------------
* 项目名称 ：run
* 项目描述 ：检测本机安装的.net运行版本
* 类 名 称 ：
* 类 描 述 ：
* 命名空间 ：
* CLR 版本 ：
* 作    者 ：fesugar
* 邮    箱 ：fesugar@fesugar.com
* 创建时间 ：12:42 2020/3/16
* 更新时间 ：12:42 2020/3/16
* 版 本 号 ：v1.0.0.0
* 参考文献 ：
*******************************************************************
* Copyright @ fesugar.com 2020. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#pragma endregion 检测注册表

#include "stdio.h"
#include "windows.h"
#include "tchar.h"
#include "strsafe.h"
//#include "stdafx.h"
//#pragma comment (lib,"Advapi32.lib") //静态库编译下 需要 否则编译失败
//#pragma comment(lib, "Msimg32.lib")  //静态库编译下 需要 否则编译失败
#pragma comment(lib, "AdvAPI32.lib")  //静态库编译下 需要 否则编译失败
#pragma comment(lib, "User32.lib") //静态库编译下 需要 否则编译失败
#pragma comment(lib,"shell32.lib")

// 为避免机器编译时候出现：SDK中某些值没有被定义的情况，先定义他们。
#ifndef SM_TABLETPC
#define SM_TABLETPC    86
#endif

#ifndef SM_MEDIACENTER
#define SM_MEDIACENTER 87
#endif

// 用于检测注册表项的名称和值名称的常量
//const TCHAR* g_szNetfx10RegKeyName = _T("Software\\Microsoft\\.NETFramework\\Policy\\v1.0");
//const TCHAR* g_szNetfx10RegKeyValue = _T("3705");
//const TCHAR* g_szNetfx10SPxMSIRegKeyName = _T("Software\\Microsoft\\Active Setup\\Installed Components\\{78705f0d - e8db - 4b2d - 8193 - 982bdda15ecd}");
//const TCHAR* g_szNetfx10SPxOCMRegKeyName = _T("Software\\Microsoft\\Active Setup\\Installed Components\\{FDC11A6F - 17D1 - 48f9 - 9EA3 - 9051954BAA24}");
//const TCHAR* g_szNetfx11RegKeyName = _T("Software\\Microsoft\\NET Framework Setup\\NDP\\v1.1.4322");
//const TCHAR* g_szNetfx20RegKeyName = _T("Software\\Microsoft\\NET Framework Setup\\NDP\\v2.0.50727");
//const TCHAR* g_szNetfx30RegKeyName = _T("Software\\Microsoft\\NET Framework Setup\\NDP\\v3.0\\Setup");
//const TCHAR* g_szNetfx30SpRegKeyName = _T("Software\\Microsoft\\NET Framework Setup\\NDP\\v3.0");
//const TCHAR* g_szNetfx30RegValueName = _T("InstallSuccess");
//const TCHAR* g_szNetfx35RegKeyName = _T("Software\\Microsoft\\NET Framework Setup\\NDP\\v3.5");
const TCHAR* g_szNetfx40RegKeyName = _T("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full");
const TCHAR* g_szNetfxStandardRegValueName = _T("Install");
const TCHAR* g_szNetfxStandardSPxRegValueName = _T("SP");
const TCHAR* g_szNetfxStandardVersionRegValueName = _T("Version");

//// .NET Framework 3.0最终版本的版本信息
//const int g_iNetfx30VersionMajor = 3;
//const int g_iNetfx30VersionMinor = 0;
//const int g_iNetfx30VersionBuild = 4506;
//const int g_iNetfx30VersionRevision = 26;
//
//// .NET Framework 3.5最终版本的版本信息
//const int g_iNetfx35VersionMajor = 3;
//const int g_iNetfx35VersionMinor = 5;
//const int g_iNetfx35VersionBuild = 21022;
//const int g_iNetfx35VersionRevision = 8;

// 函数原型声明
bool CheckNetfxBuildNumber(const TCHAR*, const TCHAR*, const int, const int, const int, const int);
//int GetNetfx10SPLevel();
int GetNetfxSPLevel(const TCHAR*, const TCHAR*);
bool IsCurrentOSTabletMedCenter();
//bool IsNetfx10Installed();
//bool IsNetfx11Installed();
//bool IsNetfx20Installed();
//bool IsNetfx30Installed();
//bool IsNetfx35Installed();
bool RegistryGetValue(HKEY, const TCHAR*, const TCHAR*, DWORD, LPBYTE, DWORD);

///******************************************************************
//Function Name: 判断.NET Framework 1.0是否安装
//Description:    Uses the detection method recommended at
//[url]http://msdn.microsoft.com/library/ms994349.aspx[/url]
//to determine whether the .NET Framework 1.0 is
//installed on the machine
//Inputs:        NONE
//Results:        .NET Framework 1.0已安装返回TRUE否则返回FALSE
//******************************************************************/
//bool IsNetfx10Installed()
//{
//	TCHAR szRegValue[MAX_PATH];
//	return (RegistryGetValue(HKEY_LOCAL_MACHINE, g_szNetfx10RegKeyName, g_szNetfx10RegKeyValue, NULL, (LPBYTE)szRegValue, MAX_PATH));
//}
//
///******************************************************************
//Function Name: 判断.NET Framework 1.1是否安装
//Description:    Uses the detection method recommended at
//[url]http://msdn.microsoft.com/library/ms994339.aspx [/url]
//to determine whether the .NET Framework 1.1 is
//installed on the machine
//Inputs:        NONE
//Results:        .NET Framework 1.1已安装返回TRUE否则返回FALSE
//******************************************************************/
//bool IsNetfx11Installed()
//{
//	bool bRetValue = false;
//	DWORD dwRegValue = 0;
//
//	if (RegistryGetValue(HKEY_LOCAL_MACHINE, g_szNetfx11RegKeyName, g_szNetfxStandardRegValueName, NULL, (LPBYTE)& dwRegValue, sizeof(DWORD)))
//	{
//		if (1 == dwRegValue)
//			bRetValue = true;
//	}
//
//	return bRetValue;
//}
//
///******************************************************************
//Function Name: 判断.NET Framework 2.0是否安装
//Description:    Uses the detection method recommended at
//[url]http://msdn.microsoft.com/library/aa480243.aspx [/url]
//to determine whether the .NET Framework 2.0 is
//installed on the machine
//Inputs:        NONE
//Results:        .NET Framework 2.0已安装返回TRUE否则返回FALSE
//******************************************************************/
//bool IsNetfx20Installed()
//{
//	bool bRetValue = false;
//	DWORD dwRegValue = 0;
//
//	if (RegistryGetValue(HKEY_LOCAL_MACHINE, g_szNetfx20RegKeyName, g_szNetfxStandardRegValueName, NULL, (LPBYTE)& dwRegValue, sizeof(DWORD)))
//	{
//		if (1 == dwRegValue)
//			bRetValue = true;
//	}
//
//	return bRetValue;
//}
//
///******************************************************************
//Function Name: 判断.NET Framework 3.0是否安装
//Description:    Uses the detection method recommended at
//[url]http://msdn.microsoft.com/library/aa964979.aspx [/url]
//to determine whether the .NET Framework 3.0 is
//installed on the machine
//Inputs:        NONE
//Results:        .NET Framework 3.0已安装返回TRUE否则返回FALSE
//******************************************************************/
//bool IsNetfx30Installed()
//{
//	bool bRetValue = false;
//	DWORD dwRegValue = 0;
//
//	// 检查InstallSuccess注册表值存在，等于1
//	if (RegistryGetValue(HKEY_LOCAL_MACHINE, g_szNetfx30RegKeyName, g_szNetfx30RegValueName, NULL, (LPBYTE)& dwRegValue, sizeof(DWORD)))
//	{
//		if (1 == dwRegValue)
//			bRetValue = true;
//	}
//
//	//补充核查，检查版本列出的版本号在注册表中，是否已有预发布版的 .NET Framework 3.0 InstallSuccess值。
//	return (bRetValue && CheckNetfxBuildNumber(g_szNetfx30RegKeyName, g_szNetfxStandardVersionRegValueName, g_iNetfx30VersionMajor, g_iNetfx30VersionMinor, g_iNetfx30VersionBuild, g_iNetfx30VersionRevision));
//}
//
///******************************************************************
//Function Name: 判断.NET Framework 3.5是否安装
//Description:    Uses the detection method recommended at
//[url]http://msdn.microsoft.com/library/cc160716.aspx [/url]
//to determine whether the .NET Framework 3.5 is
//installed on the machine
//Inputs:        NONE
//Results:        .NET Framework 3.5已安装返回TRUE否则返回FALSE
//******************************************************************/
//bool IsNetfx35Installed()
//{
//	bool bRetValue = false;
//	DWORD dwRegValue = 0;
//
//	// 检查安装的注册表值存在，等于1
//	if (RegistryGetValue(HKEY_LOCAL_MACHINE, g_szNetfx35RegKeyName, g_szNetfxStandardRegValueName, NULL, (LPBYTE)& dwRegValue, sizeof(DWORD)))
//	{
//		if (1 == dwRegValue)
//			bRetValue = true;
//	}
//
//	// 补充核查，检查版本列出的版本号在注册表中，是否已有预发布版的 .NET Framework 3.5 InstallSuccess值。
//	return (bRetValue && CheckNetfxBuildNumber(g_szNetfx35RegKeyName, g_szNetfxStandardVersionRegValueName, g_iNetfx35VersionMajor, g_iNetfx35VersionMinor, g_iNetfx35VersionBuild, g_iNetfx35VersionRevision));
//}

/******************************************************************
Function Name: 判断.NET Framework 4.0是否安装
Description:    Uses the detection method recommended at
[url]http://msdn.microsoft.com/library/cc160716.aspx [/url]
to determine whether the .NET Framework 4.0 is
installed on the machine
Inputs:        NONE
Results:        .NET Framework 4.0已安装返回TRUE否则返回FALSE
******************************************************************/
bool IsNetfx40Installed()
{
	bool bRetValue = false;
	DWORD dwRegValue = 0;

	// 检查安装的注册表值存在，等于1
	if (RegistryGetValue(HKEY_LOCAL_MACHINE, g_szNetfx40RegKeyName, g_szNetfxStandardRegValueName, NULL, (LPBYTE)&dwRegValue, sizeof(DWORD)))
	{
		if (1 == dwRegValue)
			bRetValue = true;
	}

	return bRetValue;
}
//
///******************************************************************
//Function Name: 获取.NET Framework 1.0 SP 的版本
//Description:    Uses the detection method recommended at
//[url]http://blogs.msdn.com/astebner/archive/2004/09/14/229802.aspx [/url]
//to determine what service pack for the
//.NET Framework 1.0 is installed on the machine
//Inputs:        NONE
//Results:        integer representing SP level for .NET Framework 1.0
//******************************************************************/
//int GetNetfx10SPLevel()
//{
//	TCHAR szRegValue[MAX_PATH];
//	TCHAR* pszSPLevel = NULL;
//	int iRetValue = -1;
//	bool bRegistryRetVal = false;
//
//	//需要检测操作系统上注册表项SP的版本
//	if (IsCurrentOSTabletMedCenter())
//		bRegistryRetVal = RegistryGetValue(HKEY_LOCAL_MACHINE, g_szNetfx10SPxOCMRegKeyName, g_szNetfxStandardVersionRegValueName, NULL, (LPBYTE)szRegValue, MAX_PATH);
//	else
//		bRegistryRetVal = RegistryGetValue(HKEY_LOCAL_MACHINE, g_szNetfx10SPxMSIRegKeyName, g_szNetfxStandardVersionRegValueName, NULL, (LPBYTE)szRegValue, MAX_PATH);
//
//	if (bRegistryRetVal)
//	{
//		// 格式化SP版本号： #,#,#####,#
//		pszSPLevel = _tcsrchr(szRegValue, _T(', '));
//		if (NULL != pszSPLevel)
//		{
//			// 增量指针跳过逗号
//			pszSPLevel++;
//
//			// 转换值为整数
//			iRetValue = _tstoi(pszSPLevel);
//		}
//	}
//
//	return iRetValue;
//}

/******************************************************************
Function Name: 获取.NET Framework SP 的版本
Description:    确定哪些已安装Service Pack的版本。 NET框架使用基于注册表检测方法的记载。 NET Framework的部署指南。
Inputs:        pszNetfxRegKeyName – registry key name to use for detection
pszNetfxRegValueName – registry value to use for detection
Results:        integer representing SP level for .NET Framework
******************************************************************/
int GetNetfxSPLevel(const TCHAR* pszNetfxRegKeyName, const TCHAR* pszNetfxRegValueName)
{
	DWORD dwRegValue = 0;

	if (RegistryGetValue(HKEY_LOCAL_MACHINE, pszNetfxRegKeyName, pszNetfxRegValueName, NULL, (LPBYTE)&dwRegValue, sizeof(DWORD)))
	{
		return (int)dwRegValue;
	}

	// 从注册表检索 .NET框架未安装或有某种错误的数据
	return -1;
}

/******************************************************************
Function Name: 获取.NET Framework 编译版本
Description:    从注册表检索 .NET Framework 的版本号，验证这不是一个预发布版本号
Inputs:        NONE
Results:        true if the build number in the registry is greater
than or equal to the passed in version; false otherwise
******************************************************************/
bool CheckNetfxBuildNumber(const TCHAR* pszNetfxRegKeyName, const TCHAR* pszNetfxRegKeyValue, const int iRequestedVersionMajor, const int iRequestedVersionMinor, const int iRequestedVersionBuild, const int iRequestedVersionRevision)
{
	TCHAR szRegValue[MAX_PATH];
	TCHAR* pszToken = NULL;
	TCHAR* pszNextToken = NULL;
	int iVersionPartCounter = 0;
	int iRegistryVersionMajor = 0;
	int iRegistryVersionMinor = 0;
	int iRegistryVersionBuild = 0;
	int iRegistryVersionRevision = 0;
	bool bRegistryRetVal = false;

	// 尝试建立一些注册表值
	bRegistryRetVal = RegistryGetValue(HKEY_LOCAL_MACHINE, pszNetfxRegKeyName, pszNetfxRegKeyValue, NULL, (LPBYTE)szRegValue, MAX_PATH);

	if (bRegistryRetVal)
	{
		// 此注册表值应的格式#.#.#####.##.尝试解析4部分版本浏览
		pszToken = _tcstok_s(szRegValue, _T("."), &pszNextToken);
		while (NULL != pszToken)
		{
			iVersionPartCounter++;

			switch (iVersionPartCounter)
			{
			case 1:
				// 转换主要版本为整数

				iRegistryVersionMajor = _tstoi(pszToken);
				break;
			case 2:
				// 转换次要版本值为整数
				iRegistryVersionMinor = _tstoi(pszToken);
				break;
			case 3:
				// 转换编译版本值为整数
				iRegistryVersionBuild = _tstoi(pszToken);
				break;
			case 4:
				// 转换版本号值为整数
				iRegistryVersionRevision = _tstoi(pszToken);
				break;
			default:
				break;

			}

			// 获取其它部分的版本号
			pszToken = _tcstok_s(NULL, _T("."), &pszNextToken);
		}
	}

	// Compare the version number retrieved from the registry with
	// the version number of the final release of the .NET Framework 3.0
	//从注册表中检索最后发布的 .NET Framework 3.0 的版本号码，比较版本号码
	if (iRegistryVersionMajor > iRequestedVersionMajor)
	{
		return true;
	}
	else if (iRegistryVersionMajor == iRequestedVersionMajor)
	{
		if (iRegistryVersionMinor > iRequestedVersionMinor)
		{
			return true;
		}
		else if (iRegistryVersionMinor == iRequestedVersionMinor)
		{
			if (iRegistryVersionBuild > iRequestedVersionBuild)
			{
				return true;
			}
			else if (iRegistryVersionBuild == iRequestedVersionBuild)
			{
				if (iRegistryVersionRevision >= iRequestedVersionRevision)
				{
					return true;
				}
			}
		}
	}

	// If we get here, the version in the registry must be less than the
	// version of the final release of the .NET Framework we are checking,
	// so return false
	return false;
}

bool IsCurrentOSTabletMedCenter()
{
	// Use GetSystemMetrics to detect if we are on a Tablet PC or Media Center OS
	return ((GetSystemMetrics(SM_TABLETPC) != 0) || (GetSystemMetrics(SM_MEDIACENTER) != 0));
}

/******************************************************************
Function Name: RegistryGetValue
Description:    Get the value of a reg key
Inputs:        HKEY hk – The hk of the key to retrieve
TCHAR *pszKey – Name of the key to retrieve
TCHAR *pszValue – The value that will be retrieved
DWORD dwType – The type of the value that will be retrieved
LPBYTE data – A buffer to save the retrieved data
DWORD dwSize – The size of the data retrieved
Results:        true if successful, false otherwise
******************************************************************/
bool RegistryGetValue(HKEY hk, const TCHAR* pszKey, const TCHAR* pszValue, DWORD dwType, LPBYTE data, DWORD dwSize)
{
	HKEY hkOpened;

	// Try to open the key
	if (RegOpenKeyEx(hk, pszKey, 0, KEY_READ, &hkOpened) != ERROR_SUCCESS)
	{
		return false;
	}

	// If the key was opened, try to retrieve the value
	if (RegQueryValueEx(hkOpened, pszValue, 0, &dwType, (LPBYTE)data, &dwSize) != ERROR_SUCCESS)
	{
		RegCloseKey(hkOpened);
		return false;
	}

	// Clean up
	RegCloseKey(hkOpened);

	return true;
}

int APIENTRY _tWinMain(HINSTANCE hInstance,
	HINSTANCE hPrevInstance,
	LPTSTR    lpCmdLine,
	int      nCmdShow)
{
	//int iNetfx10SPLevel = -1;
	//int iNetfx11SPLevel = -1;
	//int iNetfx20SPLevel = -1;
	//int iNetfx30SPLevel = -1;
	//int iNetfx35SPLevel = -1;
	int iNetfx40SPLevel = -1;
	TCHAR szMessage[MAX_PATH];

	// Determine whether or not the .NET Framework
	// 1.0, 1.1, 2.0 or 3.0 are installed
	//bool bNetfx10Installed = IsNetfx10Installed();
	//bool bNetfx11Installed = IsNetfx11Installed();
	//bool bNetfx20Installed = IsNetfx20Installed();

	// The .NET Framework 3.0 is an add-in that installs
	// on top of the .NET Framework 2.0. For this version
	// check, validate that both 2.0 and 3.0 are installed.
//	bool bNetfx30Installed = (IsNetfx20Installed() && IsNetfx30Installed());

	// The .NET Framework 3.5 is an add-in that installs
	// on top of the .NET Framework 2.0 and 3.0. For this version
	// check, validate that 2.0, 3.0 and 3.5 are installed.
	//bool bNetfx35Installed = (IsNetfx20Installed() && IsNetfx30Installed() && IsNetfx35Installed());

	// The .NET Framework 4.0 is an add-in that installs
	bool bNetfx40Installed = IsNetfx40Installed();

	/* 只需要检测4.0是否安装 注释掉别的
	// If .NET Framework 1.0 is installed, get the
	// service pack level
	if (bNetfx10Installed)
	{
		iNetfx10SPLevel = GetNetfx10SPLevel();

		if (iNetfx10SPLevel > 0)
			_stprintf_s(szMessage, MAX_PATH, _T(".NET Framework 1.0 service pack %i is installed."), iNetfx10SPLevel);
		else
			_stprintf_s(szMessage, MAX_PATH, _T(".NET Framework 1.0 is installed with no service packs."));

		MessageBox(NULL, szMessage, _T(".NET Framework 1.0"), MB_OK | MB_ICONINFORMATION);
	}
	else
	{
		MessageBox(NULL, _T(".NET Framework 1.0 is not installed."), _T(".NET Framework 1.0"), MB_OK | MB_ICONINFORMATION);
	}

	// If .NET Framework 1.1 is installed, get the
	// service pack level
	if (bNetfx11Installed)
	{
		iNetfx11SPLevel = GetNetfxSPLevel(g_szNetfx11RegKeyName, g_szNetfxStandardSPxRegValueName);

		if (iNetfx11SPLevel > 0)
			_stprintf_s(szMessage, MAX_PATH, _T(".NET Framework 1.1 service pack %i is installed."), iNetfx11SPLevel);
		else
			_stprintf_s(szMessage, MAX_PATH, _T(".NET Framework 1.1 is installed with no service packs."));

		MessageBox(NULL, szMessage, _T(".NET Framework 1.1"), MB_OK | MB_ICONINFORMATION);
	}
	else
	{
		MessageBox(NULL, _T(".NET Framework 1.1 is not installed."), _T(".NET Framework 1.1"), MB_OK | MB_ICONINFORMATION);
	}

	// If .NET Framework 2.0 is installed, get the
	// service pack level
	if (bNetfx20Installed)
	{
		iNetfx20SPLevel = GetNetfxSPLevel(g_szNetfx20RegKeyName, g_szNetfxStandardSPxRegValueName);

		if (iNetfx20SPLevel > 0)
			_stprintf_s(szMessage, MAX_PATH, _T(".NET Framework 2.0 service pack %i is installed."), iNetfx20SPLevel);
		else
			_stprintf_s(szMessage, MAX_PATH, _T(".NET Framework 2.0 is installed with no service packs."));

		MessageBox(NULL, szMessage, _T(".NET Framework 2.0"), MB_OK | MB_ICONINFORMATION);
	}
	else
	{
		MessageBox(NULL, _T(".NET Framework 2.0 is not installed."), _T(".NET Framework 2.0"), MB_OK | MB_ICONINFORMATION);
	}

	// If .NET Framework 3.0 is installed, get the
	// service pack level
	if (bNetfx30Installed)
	{
		iNetfx30SPLevel = GetNetfxSPLevel(g_szNetfx30SpRegKeyName, g_szNetfxStandardSPxRegValueName);

		if (iNetfx30SPLevel > 0)
			_stprintf_s(szMessage, MAX_PATH, _T(".NET Framework 3.0 service pack %i is installed."), iNetfx30SPLevel);
		else
			_stprintf_s(szMessage, MAX_PATH, _T(".NET Framework 3.0 is installed with no service packs."));

		MessageBox(NULL, szMessage, _T(".NET Framework 3.0"), MB_OK | MB_ICONINFORMATION);
	}
	else
	{
		MessageBox(NULL, _T(".NET Framework 3.0 is not installed."), _T(".NET Framework 3.0"), MB_OK | MB_ICONINFORMATION);
	}

	// If .NET Framework 3.5 is installed, get the
	// service pack level
	if (bNetfx35Installed)
	{
		iNetfx35SPLevel = GetNetfxSPLevel(g_szNetfx35RegKeyName, g_szNetfxStandardSPxRegValueName);

		if (iNetfx35SPLevel > 0)
			_stprintf_s(szMessage, MAX_PATH, _T(".NET Framework 3.5 service pack %i is installed."), iNetfx35SPLevel);
		else
			_stprintf_s(szMessage, MAX_PATH, _T(".NET Framework 3.5 is installed with no service packs."));

		MessageBox(NULL, szMessage, _T(".NET Framework 3.5"), MB_OK | MB_ICONINFORMATION);
	}
	else
	{
		MessageBox(NULL, _T(".NET Framework 3.5 is not installed."), _T(".NET Framework 3.5"), MB_OK | MB_ICONINFORMATION);
	}
	*/
	// If .NET Framework 4.0 is installed, get the
	// service pack level
	if (bNetfx40Installed)
	{
		iNetfx40SPLevel = GetNetfxSPLevel(g_szNetfx40RegKeyName, g_szNetfxStandardSPxRegValueName);

		if (iNetfx40SPLevel > 0)

			_stprintf_s(szMessage, MAX_PATH, _T(".NET Framework 4.0 service pack %i is installed."), iNetfx40SPLevel);
		else
			_stprintf_s(szMessage, MAX_PATH, _T(".NET Framework 4.0 is installed with no service packs."));

		//MessageBox(NULL, szMessage, _T(".NET Framework 4.0"), MB_OK | MB_ICONINFORMATION);
		//下面开始使用 CreateProcess 运行指定程序
		TCHAR szCmdLine[] = { TEXT("MouseRec.exe") }; //程序位置
		STARTUPINFO si; //一些必备参数设置
		memset(&si, 0, sizeof(si));
		si.cb = sizeof(si);
		si.dwFlags = STARTF_USESHOWWINDOW;
		si.wShowWindow = SW_SHOW;
		PROCESS_INFORMATION pi; //必备参数设置结束

		if (!CreateProcessW(NULL, szCmdLine, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi))
		{
			_stprintf_s(szMessage, MAX_PATH, _T("运行中发生错误，错误代码 %p "), GetLastError);
			MessageBox(NULL, szMessage, NULL, MB_OK);
			exit(0);
		}
		// 等待进程结束
		WaitForSingleObject(pi.hProcess,INFINITE);
		// 关闭句柄
		CloseHandle(pi.hProcess);
		CloseHandle(pi.hThread);
	}
	else
	{
		MessageBox(NULL, _T(".NET 运行环境未安装或已经损坏，请先安装或修复后再次尝试。"), _T(".NET Framework  4.0"), MB_OK | MB_ICONINFORMATION);

		TCHAR szCmdLine[] = { TEXT("NDP462.cmd") }; //程序位置
		STARTUPINFO si; //一些必备参数设置
		memset(&si, 0, sizeof(si));
		si.cb = sizeof(si);
		si.dwFlags = STARTF_USESHOWWINDOW;
		si.wShowWindow = SW_SHOW;
		PROCESS_INFORMATION pi; //必备参数设置结束

		if (!CreateProcessW(NULL, szCmdLine, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi))
		{
			_stprintf_s(szMessage, MAX_PATH, _T("运行中发生错误，错误代码 %p "), GetLastError);
			MessageBox(NULL, szMessage, NULL, MB_OK);
			exit(0);
		}
		// 等待进程结束
		WaitForSingleObject(pi.hProcess, INFINITE);
		// 关闭句柄
		CloseHandle(pi.hProcess);
		CloseHandle(pi.hThread);

	}

	return 0;
}