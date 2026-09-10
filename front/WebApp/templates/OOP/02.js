function Employee(name, age, sex) {
    this.name = name;
    this.age = age;
    this.sex = sex;
    this.say = function () {
        console.log("我的名字是：" + this.name);
    }
}

Employee.prototype.color = "";

function hasOwnProperty(obj, prop) {
    if (!obj.hasOwnProperty(prop)) {
        return prop in obj;
    }
    return false;
}

var employee = new Employee("小王", 22, "男");
// employee.color = "Red";
employee.hobby = "Coding";
console.log(hasOwnProperty(employee, "name"));
console.log(hasOwnProperty(employee, "color"));
console.log(hasOwnProperty(employee, "hobby"));
console.log(employee);
console.log(employee.hasOwnProperty("hobby"));

console.log("*********************************************************************************");

function Engineer() {

}

Engineer.prototype = {
    name: "默认",
    age: 0,
    say: function () {
        console.log(this.name + "  " + this.age);
    }
};

var enginerr = new Engineer();
enginerr.say();
enginerr.name = "工程师";
enginerr.age = 29;
enginerr.say();
console.log("*********************************************************************************");

function Architect() {

}

Architect.prototype = {
    constructor: Architect,
    name: "默认值",
    age: 25,
    friends: ["f1", "f2", "f3"],
    say: function () {
        console.log(this.name + " " + this.age + "  " + this.friends.length);
    }
};

var architect1 = new Architect();
architect1.say();
architect1.friends.push("f4");
architect1.say();
//architect1和architect2指向同一个原型链,所以两个对象的friends的个数一样
var architect2 = new Architect();
architect2.say();