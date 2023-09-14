/**
 * @param {number[]} nums
 * @param {Function} fn
 * @param {number} init
 * @return {number}
 */
var reduce = function(nums, fn, init) {
    if(!nums.length){
        return init;
    }
    let sum=init;
    for(let value of nums){
        sum = fn(sum, value);
    }
    return sum;
};