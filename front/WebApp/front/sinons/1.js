

require("@fatso83/mini-mocha").install();
const sinon = require("sinon");
const referee = require("@sinonjs/referee");
const fs = require("fs");
const assert = referee.assert;


function once(fn) {
    let returnValue,
        called = false;
    return function () {
        if (!called) {
            called = true;
            returnValue = fn.apply(this, arguments);
        }
        return returnValue;
    };
}

it("calls the original function", function () {
    const callback = sinon.fake();
    const proxy = once(callback);

    proxy();

    assert(callback.called);
});


it("should be able to be used instead of spies", function () {
    const foo = {
        bar: () => "baz",
    };
    // wrap existing method without changing its behaviour
    const fake = sinon.replace(foo, "bar", sinon.fake(foo.bar));

    assert.equals(fake(), "baz"); // behaviour is the same
    assert.equals(fake.callCount, 1); // calling information is saved
});

it("should be able to be used instead of stubs", function () {
    const foo = {
        bar: () => "baz",
    };
    // replace method with a fake one
    const fake = sinon.replace(foo, "bar", sinon.fake.returns("fake value"));

    assert.equals(fake(), "fake value"); // returns fake value
    assert.equals(fake.callCount, 1); // saves calling information
});


it("should create fake without behaviour", function () {
    // create a basic fake, with no behavior
    const fake = sinon.fake();

    assert.isUndefined(fake()); // by default returns undefined
    assert.equals(fake.callCount, 1); // saves call information
});



it("should create fake with custom behaviour", function () {
    // create a fake that returns the text "foo"
    const fake = sinon.fake.returns("foo");

    assert.equals(fake(), "foo");
});



it("should create a fake that 'returns'", function () {
    const fake = sinon.fake.returns("apple pie");

    assert.equals(fake(), "apple pie");
});


it("should create a fake that 'throws'", function () {
    const fake = sinon.fake.throws(new Error("not apple pie"));

    // Expected to throw an error with message 'not apple pie'
    assert.exception(fake, { name: "Error", message: "not apple pie" });
});


it("should create a fake that 'yields'", function () {
    const fake = sinon.fake.yields(null, "file content");
    const anotherFake = sinon.fake();

    sinon.replace(fs, "readFile", fake);
    fs.readFile("somefile", (err, data) => {
        // called with fake values given to yields as arguments
        assert.isNull(err);
        assert.equals(data, "file content");
        // since yields is synchronous, anotherFake is not called yet
        assert.isFalse(anotherFake.called);

        sinon.restore();
    });

    anotherFake();
});



it("should create a fake that 'yields asynchronously'", function () {
    const fake = sinon.fake.yieldsAsync(null, "file content");
    const anotherFake = sinon.fake();

    sinon.replace(fs, "readFile", fake);
    fs.readFile("somefile", (err, data) => {
        // called with fake values given to yields as arguments
        assert.isNull(err);
        assert.equals(data, "file content");
        // since yields is asynchronous, anotherFake is called first
        assert.isTrue(anotherFake.called);

        sinon.restore();
    });

    anotherFake();
});

it("should create a fake that 'yields asynchronously'", function () {
    const fake = sinon.fake.yieldsAsync(null, "file content");
    const anotherFake = sinon.fake();

    sinon.replace(fs, "readFile", fake);
    fs.readFile("somefile", (err, data) => {
        // called with fake values given to yields as arguments
        assert.isNull(err);
        assert.equals(data, "file content");
        // since yields is asynchronous, anotherFake is called first
        assert.isTrue(anotherFake.called);

        sinon.restore();
    });

    anotherFake();
});



it("should have working callback", function () {
    const f = sinon.fake();
    const cb1 = function () {};
    const cb2 = function () {};

    f(1, 2, 3, cb1);
    f(1, 2, 3, cb2);

    assert.isTrue(f.callback === cb2);
    // spy call methods:
    assert.isTrue(f.getCall(1).callback === cb2);
    assert.isTrue(f.lastCall.callback === cb2);
});



it("should have working firstArg", function () {
    const f = sinon.fake();
    const date1 = new Date();
    const date2 = new Date();

    f(date1, 1, 2);
    f(date2, 1, 2);

    assert.isTrue(f.firstArg === date2);
});


it("should have working lastArg", function () {
    const f = sinon.fake();
    const date1 = new Date();
    const date2 = new Date();

    f(1, 2, date1);
    f(1, 2, date2);

    assert.isTrue(f.lastArg === date2);
    // spy call methods:
    assert.isTrue(f.getCall(0).lastArg === date1);
    assert.isTrue(f.getCall(1).lastArg === date2);
    assert.isTrue(f.lastCall.lastArg === date2);
});


it("should be able to be added to the system under test", function () {
    const fake = sinon.fake.returns("42");

    sinon.replace(console, "log", fake);

    assert.equals(console.log("apple pie"), "42");

    // restores all replaced properties set by sinon methods (replace, spy, stub)
    sinon.restore();

    assert.isUndefined(console.log("apple pie"));
    assert.equals(fake.callCount, 1);
});


