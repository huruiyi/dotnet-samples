const strDate1 = '2023-01-01'
const strDate2 = '2023-01-01'

const date1 = new Date(strDate1)
const date2 = new Date(strDate2)
console.log(date1)
console.log(date2)

console.log(date1.getTime())
console.log(date2.getTime())
const ms = date2.getTime() - date1.getTime()
console.log(ms / 1000 / 24 / 60 / 60)
