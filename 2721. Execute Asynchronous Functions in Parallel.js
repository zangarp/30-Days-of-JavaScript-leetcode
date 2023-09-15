/**
 * @param {Array<Function>} functions
 * @return {Promise<any>}
 */
var promiseAll = function(functions) {
    let resolve, reject;
    const promise = new Promise((...args) => [resolve, reject] = args);

    let count = functions.length;
    const result = new Array(count).fill(null);

    for(let i = 0; i < functions.length; i++) {
        const fn = functions[i];
        fn().then(res => {
            result[i] = res;
            if(--count === 0) resolve(result);
        }).catch(err => reject(err));
    }

    return promise;
};
/**
 * const promise = promiseAll([() => new Promise(res => res(42))])
 * promise.then(console.log); // [42]
 */