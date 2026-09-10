/**
 * @使用 call() 方法，您可以编写能够在不同对象上使用的方法。
 * @通过 apply() 方法，您能够编写用于不同对象的方法。
 */
const person = {
    fullName: function () {
        return this.firstName + " " + this.lastName;
    },
    info: function (city, country) {
        return this.firstName + " " + this.lastName + "," + city + "," + country;
    }
};

const person1 = {
    firstName: "Bill",
    lastName: "Gates",
};
const person2 = {
    firstName: "Steve",
    lastName: "Jobs",
};


// call() 和 apply() 之间的区别
// 不同之处是：
// call() 方法分别接受参数。
// apply() 方法接受数组形式的参数。
// 如果要使用数组而不是参数列表，则 apply() 方法非常方便。

console.log(person.fullName());
console.log(person.fullName.call(person1));
console.log(person.fullName.apply(person1));
console.log(person.info.apply(person1, ["California", "USA"]))
console.log(person.info.call(person1, "New York", "USA"))
console.log()


console.log(person.fullName.call(person1))
console.log(person.fullName.call(person2))
console.log(person.fullName.apply(person1))
console.log(person.fullName.apply(person2))
// console.log(person1.fullName()) error
// console.log(person2.fullName()) error
console.log()

const val1 = Math.max(1, 2, 3);
const val2 = Math.max.apply(null, [1, 2, 3]);
const val3 = Math.max.apply(this, [1, 2, 3]);
const val4 = Math.max.apply(Math, [1, 2, 3]);
const val5 = Math.max.apply(" ", [1, 2, 3]);
const val6 = Math.max.apply(0, [1, 2, 3]);

console.log(val1 + " " + val2 + " " + val3 + " " + val4 + " " + val5 + " " + val6);

const nums = [1, 2, 3, 4];
console.log(...nums.concat(5));
console.log(nums)
