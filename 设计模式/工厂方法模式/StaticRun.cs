namespace 设计模式.工厂方法模式;
class StaticRun{
    static void Run(){
        Orchard appleOrchard = new AppleOrchard();
        Fruit apple = appleOrchard.CreateFruit();
        apple.plant();

        Orchard pearOrchard = new PearOrchard();
        Fruit pear = pearOrchard.CreateFruit();
        pear.plant();
    }
}