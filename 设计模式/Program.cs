using 设计模式.简单工厂模式;

#region 简单设计模式
var fruit = FruitFactory.Produce(FruitOptions.Apple);
fruit.plant();
#endregion
