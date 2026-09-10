var p1 = new Object();
p1.name = "刘帅哥";
p1.age = 16;
p1.sex = "男";
console.log(p1.name + "  " + p1.age + "  " + p1.sex);

console.log("*********************************************************************************");

var p2 = {
    name: "马天鹏",
    age: 15,
    sex: "女",
    say: function () {
        console.log("呵呵");
    }
};
console.log(p2.name + "  " + p2.age + "  " + p2.sex);
p2.say();

