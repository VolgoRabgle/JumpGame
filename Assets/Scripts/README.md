#脚本代码命名标准：
私有变量： 下划线开头，若由多个单词组成则从第二个单词开始，首字母大写。 如： _isPrivateValue
共有变量/局部变量： 首字母小写，若由多个单词组成则从第二个单词开始，首字母大写。 如： isPublicValue
函数/脚本名： 每个单词的首字母都大写。 如： FounctionOne()



#各脚本功能描述：（脚本名称——功能——所属）

GameControl————控制玩家角色,以玩家为基准创建新的方块————player
GameControl————同上，以生成的方块为基准生成下一方块————player

CubeControl————控制方块状态，如生成和销毁————Cube

CameraFellow————摄像机跟随————MainCamera


#物体尺寸：
player： 0.5 x 0.5 x 0.5
Cube: 2 x 2 x 2  


#建议光照（可自行调节）
Position  x: 0    |  y: 3    |  z: 0
Rotation  x: 50   |  y: -100 |  z: 0
Scale     x: 1    |  y: 1    |  z: 1  (没啥用)

#初始主摄像机设置
Position  x: 3    |  y: 6    |  z: -3
Rotation  x: 40   |  y: -45  |  z: 0
Scale     x: 1    |  y: 1    |  z: 1
Pojection: Orthographic