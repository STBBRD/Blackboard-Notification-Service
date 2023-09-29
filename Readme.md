# 黑板通知服务 Blackboard Notification Service
## 用法
### "Blackboard Notification Service.exe" Title Subtitle (-t ShowTime) (-bottom)
- 其中 Title 和 Subtitle 必须放在第一个和第二个启动参数位置，剩余两个顺序随便，也可以不放
- 当 Subtitle 为 "" 时，Subtitle 文本块隐藏
- 如果没有 -t 指定 ShowTime，默认展示2秒
- -t 指定的展示时间不含动画时间
- -bottom 可以展示类似于安卓 Toast 的通知，仅能展示 Title 内容，但仍需填写 Subtitle，不然会崩溃
- 如果没有 -bottom，会在屏幕顶部展示通知