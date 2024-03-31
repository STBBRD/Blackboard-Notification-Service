; 脚本由 Inno Setup 脚本向导 生成！
; 有关创建 Inno Setup 脚本文件的详细资料请查阅帮助文档！

#define MyAppName "ZongziTEK 黑板通知服务"
#define MyAppVersion "1.1"
#define MyAppPublisher "ZongziTEK"
#define MyAppURL "https://github.com/STBBRD/Blackboard-Notification-Service/"
#define MyAppExeName "bns.exe"

[Setup]
; 注: AppId的值为单独标识该应用程序。
; 不要为其他安装程序使用相同的AppId值。
; (若要生成新的 GUID，可在菜单中点击 "工具|生成 GUID"。)
AppId={{92ECD1B1-7ACD-4523-836F-D1F98FB9AF39}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={userappdata}\Blackboard Notification Service
DisableDirPage=yes
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
; 移除以下行，以在管理安装模式下运行（为所有用户安装）。
PrivilegesRequired=lowest
OutputDir=D:\
OutputBaseFilename=Setup-BNS
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "chinesesimp"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "D:\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
; 注意: 不要在任何共享系统文件上使用“Flags: ignoreversion”

[Icons]
; Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"

