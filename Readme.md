# 黑板通知服务 Blackboard Notification Service
## 用法
### "Blackboard Notification Service.exe" Title Subtitle (-t ShowTime) (-bottom)
- 其中Title和Subtitle必须放在第一个和第二个启动参数位置，剩余两个顺序随便，也可以不放
- 如果没有-t指定ShowTime，默认展示2秒
- -bottom可以展示类似于安卓Toast的通知，仅能展示Title内容，但仍需填写Subtitle，不然会崩溃
- 如果没有-bottom，会在屏幕顶部展示通知