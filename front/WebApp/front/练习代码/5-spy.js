function createSpy(targetFunc) {
    const spy = () => {
        spy.args = arguments
        console.log(arguments)
        spy.returnValue = targetFunc.apply(this, arguments)
        return spy.returnValue;
    }
    return spy;
}

const sum = (a, b) => a + b;

const spiedSum = createSpy(sum)
const xx = spiedSum(2, 3);

console.log(spiedSum.args)
console.log("+++++++++++++++++++++++++++++++")
console.log(spiedSum.returnValue)
