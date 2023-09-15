class Calculator {

    /**
     * @param {number} value
     */
    constructor(value) {
        this.base =  value
    }

    /**
     * @param {number} value
     * @return {Calculator}
     */
    add(value){
        this.base = this.base + value;
        return new Calculator(this.base);
    }

    /**
     * @param {number} value
     * @return {Calculator}
     */
    subtract(value){
        this.base = this.base - value;
        return new Calculator(this.base);
    }

    /**
     * @param {number} value
     * @return {Calculator}
     */
    multiply(value) {
        this.base =  this.base * value;
        return new Calculator(this.base);
    }

    /**
     * @param {number} value
     * @return {Calculator}
     */
    divide(value) {
        if(value == 0) throw new Error("Division by zero is not allowed");
        this.base = this.base/value;
        return new Calculator(this.base);
    }

    /**
     * @param {number} value
     * @return {Calculator}
     */
    power(value) {
        this.base = Math.pow(this.base,value);
        return new Calculator(this.base);
    }

    /**
     * @return {number}
     */
    getResult() {
        return this.base;
    }
}