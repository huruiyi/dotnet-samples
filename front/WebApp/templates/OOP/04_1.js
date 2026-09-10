function Parent() {
    this.pval = "父类";
    this.BaseInfo = function () {
        console.info("父类--BaseInfo();")
    }
}

function Son() {
    this.sval = "子类";
    Parent.call(this);
}

var s1 = new Son();
console.info(s1.pval + "  " + s1.sval);
s1.BaseInfo();



