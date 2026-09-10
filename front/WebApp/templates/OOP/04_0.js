function Parent(name, age) {
    this.pv = "父类";
    this.name = name;
    this.age = age;
    this.PSay = function () {
        console.info("父类--PSay();" + this.name + "  " + this.age);
    }
}

//原型方法不可继承
Parent.prototype.proSay = function () {
    console.info("父类--proSay();" + this.name + "==" + this.age);
}

function Son(name, age) {

//Parent.apply(this,arguments)
    Parent.call(this, name, age); //===>  Parent();
    this.sv = "子类"
}

Son.prototype.sonSay = function () {
    console.info(this.sv + " " + this.pv);
}

var s1 = new Son("吕帅哥", 23);
console.info(s1.pv);
s1.PSay();
// s1.proSay();