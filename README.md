<br />项目资源及演示视频：链接：https://pan.baidu.com/s/1k_Gd9r7QGo_A_hP1JSqWrA 
提取码：bgj1
# 说明
这个项目是一个rts游戏的子系统项目，同时也是作者设计模式学习项目，实现了一些基本功能，目前项目还不完善，许多功能还有待补充
<br />项目整体结构类图位于此仓库的**项目结构.jpg**文件中，请下载查看
## 项目说明
此项目中大量运用设计模式，目前包括状态模式、外观模式、单例模式、中介者模式、桥接模式、工厂模式、建造者模式等十余种设计模式。实现了一些基本功能，包括场景切换、角色系统、兵营系统、能量系统、事件系统、关卡系统、成就系统、UI系统
## 角色系统
玩家可以建造的士兵有四种，关卡生成的敌人士兵有三种，士兵会自动进行索敌和攻击
## 兵营系统
目前没有做建造兵营，只能在现有的兵营上进行士兵创建。通过升级兵营可以建造更高等级的士兵以及有不同武器种类的士兵，随着等级提高，建造士兵需要的能量和时间都会增加，士兵的攻击力和血量也会提高
## 能量系统
士兵的建造需要消耗能量，能量随着时间恢复
## 事件系统
对于事件通知专门设计了一个事件系统来管理
## 关卡系统
每一关的目标是消灭一定数量的敌人，达到目标后自动进入下一关
## 成就系统
目前只完成了本地储存击杀的最多敌人数量和通过的最多关卡数量
## UI系统
目前完成了基础游戏UI和兵营UI的显示
