/**
 * 使用class关键字申明一个类，类名为Parent
 */
class Parent {

    //constructor方法就是Parent的构造方法
    //可以使用它来初始化Parent类的属性
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }

    //直接申明Parent类的方法，say
    say() {
        return this.name + "---->" + this.age;
    }

    //使用static关键字申明静态方法
    //注意静态方法属于类，而不属于对象
    static sayHell() {
        alert("Hello 刘帅哥");
    }
}

//错误
//			new Parent().sayHello();
//正确，该方法数据类
//			Parent.sayHell();

//			let p1 = new Parent("阿里巴巴",20);
//
//			alert(p1.say())


//使用extends来申明Son类继承Parent类
class Son extends Parent {

    constructor(name, age, sex) {
        //使用super关键字表示父类（超类）
        super(name, age);
        this.sex = sex;
    }

    sayWord() {
        alert(this.sex + "----->" + this.name + "----------" + this.age);
    }

    //使用父类中的同名方法，会覆盖父类方法（override）
    say() {
        return "哈哈";
    }

}

let p1 = new Son("阿里巴巴", 15, "男");
//p1.sayWord();
alert(p1.say());
