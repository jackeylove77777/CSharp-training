namespace 设计模式.工厂方法模式;
class AppleOrchard:Orchard{
    public Fruit CreateFruit(){
        return new Apple();
    }
}