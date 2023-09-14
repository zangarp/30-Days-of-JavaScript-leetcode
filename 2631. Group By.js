/**
 * @param {Function} fn
 * @return {Array}
 */
Array.prototype.groupBy = function(fn) {
    return this.reduce((result, item) => {
        const key = fn(item);
        if (!(key in result)) {
            result[key] = [];
        }
        result[key].push(item);
        return result;
    }, {});
};

/**
 * [1,2,3].groupBy(String) // {"1":[1],"2":[2],"3":[3]}
 */