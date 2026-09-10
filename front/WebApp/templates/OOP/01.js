function Person(name, age, sex, color) {
    this.name = name;
    this.age = age;
    this.sex = sex;
    this.color = color;
    this.say = function () {
        console.log("我的名字是：" + this.name);
    }
}

var p3 = new Person("Mariala", 23, "未知", "黑色");
console.log("1: " + (p3 instanceof Person));
//检测p3是否指向Person的原型对象
console.log("2: " + Person.prototype.isPrototypeOf(p3));
//检测p3的构造器是否指向Person对象
console.log("3: " + (p3.constructor == Person));
//检测p3是否是否有属性name
console.log("4: " + p3.hasOwnProperty("name"));
//检测p3是否是否有属性nameXXXX
console.log("5: " + p3.hasOwnProperty("nameXXXX"));
console.log("6: " + p3.name + "  " + p3.age + "  " + p3.sex + "  " + p3.color);
p3.say();

console.log("*********************************************************************************");

Person.prototype.info = function (name, age, sex, color) {
    console.log();
    console.log(arguments.length + ":" + name + "  " + age + "  " + sex + "  " + color);
};
var p4 = new Person("p4Mariala", 23, "未知", "黑色");
p4.info(p4.name, p4.age, p4.sex, p4.sex);

console.log("*********************************************************************************");

Person.prototype.info = function (name, age, sex) {
    console.log(arguments.length + ":" + name + "  " + age + "  " + sex);
};
var p5 = new Person("p4Mariala", 23, "未知");
p5.info(p5.name, p5.age, p5.sex);

console.log("*********************************************************************************");

Person.prototype.info = function (name, age) {
    console.log(arguments.length + ":" + name + "  " + age);
};
var p6 = new Person("p4Mariala", 23);
p6.info(p6.name, p6.age);

console.log("*********************************************************************************");

var p7 = new Person("p4Mariala", 23, "未知");
// p7.info(p7.name, p7.age, p7.sex);
console.log(p7.name);
console.log(p7.hasOwnProperty("name"));
console.log("name" in p7);
delete p7.name;
console.log(p7.name);
console.log(p7.hasOwnProperty("name"));
console.log("name" in p7);