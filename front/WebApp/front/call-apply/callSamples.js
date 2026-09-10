/**
 * @使用 call() 方法，您可以编写能够在不同对象上使用的方法。
 * @通过 apply() 方法，您能够编写用于不同对象的方法。
 */
var person = {
    firstName: "Bill",
    lastName: "Gates",
    fullName: function () {
        return this.firstName + " " + this.lastName;
    },
    infos: function (city, country) {
        return this.firstName + " " + this.lastName + "," + city + "," + country;
    }
}

console.log(person.fullName());

var person1 = {
    firstName: "Bill",
    lastName: "Gates",
}
var person2 = {
    firstName: "Mary",
    lastName: "Doe",
}

console.log(person.fullName.call(person1));
console.log(person.fullName.call(person2));


var person3 = {
    firstName: "John",
    lastName: "Doe",
}

console.log(person.infos.call(person3, "California", "USA"));
