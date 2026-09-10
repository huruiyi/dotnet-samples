function Parent(name, age) {
    this.pval = "父类";
    this.name = name;
    this.age = age;
    this.BaseInfo = function () {
        console.info("父类--BaseInfo();" + this.name + "  " + this.age);
    }
}

function Son(name, age) {
    Parent.call(this, name, age);
    this.sval = "子类";
}

var s1 = new Son("小明", "50");
console.info(s1.pval + "  " + s1.sval);
s1.BaseInfo();

