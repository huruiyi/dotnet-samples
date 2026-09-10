function Parent() {
    this.pv = "父类";
}

Parent.prototype.pSay = function () {
    console.info(this.pv);
};

function Son() {
    this.sv = "子类"
}

//原型继承
Son.prototype = new Parent();
Son.prototype.sSay = function () {
    console.info(this.sv + "    " + this.pv);
};

Son.prototype.pSay = function () {
    console.info("继承")
};

console.log("*******************************")
var p1 = new Parent();
p1.pSay();
console.info(p1);
console.log("*******************************")
var s1 = new Son();
s1.pSay();
s1.sSay();
console.info(s1);
console.log("*******************************")
