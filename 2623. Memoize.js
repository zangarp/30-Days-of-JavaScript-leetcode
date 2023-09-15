/**
 * @param {Function} fn
 */

function memoize(fn) {
    const test = {};
    return function(...args) {
        const key = args.toString();
        if (key in test) {
            return test[key];
        }
        else {
            test[key] = fn(...args);
            return test[key];
        }
    }
}


/**
 * let callCount = 0;
 * const memoizedFn = memoize(function (a, b) {
 *	 callCount += 1;
 *   return a + b;
 * })
 * memoizedFn(2, 3) // 5
 * memoizedFn(2, 3) // 5
 * console.log(callCount) // 1
 */