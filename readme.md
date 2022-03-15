# Asp.net core基础知识

### 中间件以及自定义中间件

### 异常处理

* 异常处理页，Asp.net core MVC开发中，框架提供的异常处理页或者自定义的自定义处理页
* Asp.net core web api通常使用异常过滤器或者异常处理的Attribute
* 业务逻辑异常和应用异常应分开处理

# 常见设计模式

## 简单工厂模式

案例以果园种植出发，定义Fruit接口，定义Apple和Banana类继承自Fruit接口，通过FruitFactory类的Produce方法并传参FruitOptions枚举类（用来选择要创建的水果种类）来创造水果。

弊端：假设现在要增加一个Watermelon类，则需要对FruitOptions和FruitFactory的Produce方法进行修改，不够灵活

## 工厂方法模式

定义了果园接口Orchard,并且在其中定义了抽象方法CreateFruit,返回Fruit接口,创造水果类的方法由Orchard的实现类来实现，而此时想要添加Watermelon类，只需要再创建一个WatermelonOrchard类实现Orchard接口。不用修改已经写过的代码。

# 多线程编程

* thread01（Thread类的简单使用，以及如何使用带参委托）
* 模拟黄牛抢票，使用了ThreadPool线程池类 

# 文件系统

todo

# 多进程编程

todo

# 系统管理

todo

# 并行编程

todo

# Windows注册表

todo

# Office操作

todo

# 数据结构和排序算法

todo

# 反射

todo

# 网络编程

todo



