function Parent(name, age) {
    this.name = name;
    this.age = age;
}

Parent.prototype.parentSay = function () {
    console.info(this.name + "----" + this.age);
};

function Son(name, age, sex) {
    Parent.call(this, name, age);
    this.sex = sex;
}

Son.prototype = new Parent();

Son.prototype.sonSay = function () {
    console.info("哈哈");
};

var s1 = new Son("123", 16, "男");

s1.sonSay();
s1.parentSay();
