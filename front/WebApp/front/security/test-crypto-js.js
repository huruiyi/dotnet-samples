const CryptoJS = require("crypto-js");

function test_Plain() {
  const ciphertext = CryptoJS["AES"].encrypt('my message', 'secret123').toString();

  const bytes = CryptoJS["AES"].decrypt(ciphertext, 'secret123');
  const originalText = bytes.toString(CryptoJS.enc.Utf8);

  console.log(originalText);
}

function test_obj() {
  const data = [{id: 1}, {id: 2}];

  var cipher = JSON.stringify(data);
  const ciphertext = CryptoJS["AES"].encrypt(cipher, 'secret-obj').toString();

  const bytes = CryptoJS["AES"].decrypt(ciphertext, 'secret-obj');
  const decryptedData = JSON.parse(bytes.toString(CryptoJS.enc.Utf8));

  console.log(decryptedData);

}


test_obj()
