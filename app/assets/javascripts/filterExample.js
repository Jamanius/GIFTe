function Item(name, category, price) {
    this.name = ko.observable(name);
    this.category = ko.observable(category);
    this.price = ko.observable(price);
    this.priceWithTax = ko.dependentObservable(function() {
        return (this.price() * 1.05).toFixed(2);
    }, this);
}

var viewModel = {
    categories: ["Bread", "Dairy", "Fruits", "Vegetables"],
    items: ko.observableArray([]),
    filter: ko.observable(""),
    search: ko.observable(""),
    addItem: function() {
        this.items.push(new Item("New", "", 1));
    },
    removeItem: function(item) {
        this.items.remove(item);
    }
};

//ko.utils.arrayFilter - filter the items using the filter text
viewModel.filteredItems = ko.dependentObservable(function() {
    var filter = this.filter().toLowerCase();
    if (!filter) {
        return this.items();
    } else {
        return ko.utils.arrayFilter(this.items(), function(item) {
            return ko.utils.stringStartsWith(item.name().toLowerCase(), filter);
        });
    }
}, viewModel);


//ko.utils.arrayForEach - return a total by adding all prices
viewModel.total = ko.dependentObservable(function() {
    var total = 0;
    ko.utils.arrayForEach(this.filteredItems(), function(item) {
        var value = parseFloat(item.priceWithTax());
        if (!isNaN(value)) {
            total += value;
        }
    });
    return total.toFixed(2);
}, viewModel);


//ko.utils.arrayFirst - identify the first matching item by name
viewModel.firstMatch = ko.dependentObservable(function() {
    var search = this.search().toLowerCase();
    if (!search) {
        return null;
    } else {
        return ko.utils.arrayFirst(this.filteredItems(), function(item) {
            return ko.utils.stringStartsWith(item.name().toLowerCase(), search);
        });
    }
}, viewModel);

//ko.utils.arrayMap - get a list of used categories
viewModel.justCategories = ko.dependentObservable(function() {
    var categories = ko.utils.arrayMap(this.items(), function(item) {
        return item.category();
    });
    return categories.sort();
}, viewModel);

//ko.utils.arrayGetDistinctValues - get a unique list of used categories
viewModel.uniqueCategories = ko.dependentObservable(function() {
    return ko.utils.arrayGetDistinctValues(viewModel.justCategories()).sort();
}, viewModel);

//ko.utils.compareArrays - find any unused categories
viewModel.missingCategories = ko.dependentObservable(function() {
    //find out the categories that are missing from uniqueNames
    var differences = ko.utils.compareArrays(viewModel.categories, viewModel.uniqueCategories());
    //return a flat list of differences
    var results = [];
    ko.utils.arrayForEach(differences, function(difference) {
        if (difference.status === "deleted") {
            results.push(difference.value);
        }
    });
    return results;
}, viewModel);

//ko.utils.arrayMap - prepare items to be sent back to server
viewModel.mappedItems = ko.dependentObservable(function() {
    var items = ko.toJS(this.items);
    return ko.utils.arrayMap(items, function(item) {
        delete item.priceWithTax;
        return item;
    });
}, viewModel);

//a JSON string that we got from the server that wasn't automatically converted to an object
var JSONdataFromServer = '[{"name":"Peach","category":"Fruits","price":1},{"name":"Plum","category":"Fruits","price":0.75},{"name":"Donut","category":"Bread","price":1.5},{"name":"Milk","category":"Dairy","price":4.50}]';

//parse into an object
var dataFromServer = ko.utils.parseJson(JSONdataFromServer);

//do some basic mapping (without mapping plugin)
var mappedData = ko.utils.arrayMap(dataFromServer, function(item) {
    return new Item(item.name, item.category, item.price);
});

viewModel.items(mappedData);

ko.applyBindings(viewModel);