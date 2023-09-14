/**
 * @param {string} val
 * @return {Object}
 */
var expect = function(val) {
    function toBe(v){
        if(val===v){
            return true
        }
        else{
            throw "Not Equal"
        }
    }
    function notToBe(v){
        if(val!==v){
            return  true
        }
        else{
            throw "Equal"
        }
    }
    return {toBe,notToBe}
};

/**
 * expect(5).toBe(5); // true
 * expect(5).notToBe(5); // throws "Equal"
 */