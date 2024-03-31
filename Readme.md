# 黑板通知服务 Blackboard Notification Service
## 用法
### 先从注册表获取黑板通知服务路径
以 C# 为例

```csharp
        public static string GetBNSPath()
        {
            string keyPath = @"Software\Microsoft\Windows\CurrentVersion\Uninstall\{92ECD1B1-7ACD-4523-836F-D1F98FB9AF39}_is1";
            string valueName = "InstallLocation";

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if (key != null)
                {
                    object value = key.GetValue(valueName);
                    if (value != null)
                    {
                        return value.ToString() + "bns.exe";
                    }
                }
            }

            return null;
        }
```
### 再通过启动参数调用黑板通知服务
```
bns.exe Title Subtitle (-t ShowTime) (-bottom)
```
以 C# 为例

```csharp
        private void ShowNotificationBNS(string title, string subtitle, double time, bool isBottom)
        {
            string timeString = time.ToString();

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                if (GetBNSPath() != null) startInfo.FileName = GetBNSPath();
                else return;

                startInfo.Arguments = "\"" + title + "\"" + " \"" + subtitle + "\" -t " + timeString;
                if (isBottom) startInfo.Arguments += " -bottom";

                Process.Start(startInfo);
            }
            catch { }
        }
```
- 其中 Title 和 Subtitle 必须放在第一个和第二个启动参数位置，剩余两个顺序随便，也可以不放
- 当 Subtitle 为 "" 时，Subtitle 文本块隐藏
- 如果没有 -t 指定 ShowTime，默认展示2秒
- -t 指定的展示时间不含动画时间
- -bottom 可以展示类似于安卓 Toast 的通知，仅能展示 Title 内容
- 如果没有 -bottom，会在屏幕顶部展示通知
