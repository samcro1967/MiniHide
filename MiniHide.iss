#define PublishDir "U:\Users\mark\Documents\Visual Studio\publish\MiniHide"
#define AppExe "MiniHide.exe"

[Setup]
AppId=MiniHide
AppName=MiniHide
AppVersion=1.0.0
AppPublisher=MiniSuite
DefaultDirName={localappdata}\MiniHide
DefaultGroupName=MiniHide
OutputDir={#PublishDir}
OutputBaseFilename=MiniHideSetup_v1.0.0
SetupIconFile=Resources\MiniHide.ico
Compression=lzma
SolidCompression=yes
PrivilegesRequired=lowest
CloseApplications=yes

DisableProgramGroupPage=no
UninstallDisplayIcon={app}\{#AppExe}

[Tasks]
Name: "desktopicon"; Description: "Create a desktop shortcut"; Flags: unchecked
Name: "startmenuicon"; Description: "Create a Start Menu shortcut"; Flags: unchecked

[Files]
Source: "{#PublishDir}\{#AppExe}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#PublishDir}\Readme.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#PublishDir}\License.txt"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\MiniHide"; Filename: "{app}\MiniHide.exe"; Tasks: startmenuicon
Name: "{group}\Uninstall MiniHide"; Filename: "{uninstallexe}"; Tasks: startmenuicon
Name: "{group}\README"; Filename: "notepad.exe"; Parameters: """{app}\Readme.txt"""; Tasks: startmenuicon
Name: "{group}\LICENSE"; Filename: "notepad.exe"; Parameters: """{app}\License.txt"""; Tasks: startmenuicon

Name: "{autodesktop}\MiniHide"; Filename: "{app}\MiniHide.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\{#AppExe}"; Description: "Launch MiniHide"; WorkingDir: "{app}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: filesandordirs; Name: "{localappdata}\MiniHide"