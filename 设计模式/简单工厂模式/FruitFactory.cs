namespace 设计模式.简单工厂模式;

class FruitFactory{
    public static Fruit Produce(FruitOptions option) => option switch
    {
        FruitOptions.Apple => new Apple(),
        FruitOptions.Banana => new Banana(),
        _ => throw new InvalidOperationException()
    };
}