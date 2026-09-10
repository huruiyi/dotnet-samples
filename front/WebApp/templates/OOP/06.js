/**
 * 定义一个类，人类
 */
class Person {
    constructor(name, age, sex) {
        this.name = name;
        this.age = age;
        this.sex = sex;
    }

    say(msg) {
        console.info(msg);
    }

    showInfos() {
        console.info(this.name + "---" + this.age + "----" + this.sex);
    }

    /**
     * 静态方法
     */
    static show(msg) {
        console.info(msg);
    }

}

/**
 * 语法糖
 */

var p1 = new Person("萝叔叔", 16, "男");
//			p1.say("嘿嘿，果然是个大帅哥");
//			p1.showInfos();
//			Person.show("嘿嘿");

class Children extends Person {
    constructor(name, sex, age, height) {
        super(name, age, sex); //在子类调用父类的构造函数，必须放在首行
        this.height = height;
    }
}

var s1 = new Children("123", "男", 5, 150);
s1.say("呵呵，我是子类");
s1.showInfos();
