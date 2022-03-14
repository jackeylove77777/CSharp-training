namespace 设计模式.工厂方法模式;
class PearOrchard:Orchard{
    public Fruit CreateFruit(){
        return new Pear();
    }
}