//LK wait for the doc to know about knockout
// $( document ).ready(function() {
//     prepareKOGiftPage();
// });

// function prepareKOGiftPage(){
//     ko.applyBindings(new GiftListViewModel());
//     slideHide();
//     $(".pane").hide();
// };

//LK dummyData
// var fakeData = [{id: "1", title: "Carrots", category: "Edible", description: "In JavaScript, objects are data (variables), with properties and methods. Almost everything in JavaScript are treated as objects. Dates, Arrays, Strings, Functions.... In JavaScript you can also create your own objects. This example creates an object called person, and adds four properties to it:"},
// {id: "2", title: "Boots", category: "Wearable", description: "In JavaScript, objects are data (variables), with properties and methods. Almost everything in JavaScript are treated as objects. Dates, Arrays, Strings, Functions.... In JavaScript you can also create your own objects. This example creates an object called person, and adds four properties to it:"},
// {id: "3", title: "UI Design", category: "Useable", description: "In JavaScript, objects are data (variables), with properties and methods. Almost everything in JavaScript are treated as objects. Dates, Arrays, Strings, Functions.... In JavaScript you can also create your own objects. This example creates an object called person, and adds four properties to it:"},
// {id: "4", title: "Cam", category: "Edible", description: "In JavaScript, objects are data (variables), with properties and methods. Almost everything in JavaScript are treated as objects. Dates, Arrays, Strings, Functions.... In JavaScript you can also create your own objects. This example creates an object called person, and adds four properties to it:"}
// ];

// Overall viewmodel for this screen, along with initial state
// function GiftListViewModel() {
//     //data
//     var self = this;
//     self.gifts = ko.observableArray([]);
//     self.filter = ko.observable("");


//     //operations
//     self.gifts(DataRetrieve());
//     self.CategoryChoice = ko.observable(true);
//     self.giftCategory = ko.observable();

//     self.filteredgifts = ko.computed(function() {
//         var filter = self.filter().toLowerCase();
//         if (!filter) {
//             return self.gifts();
//         } else {
//             return ko.utils.arrayFilter(self.gifts(), function(item) {
//                 if (item.title.toLowerCase().indexOf(filter) === 0) {
//                     return item;
//                 };
//             });
//         }
//     }, GiftListViewModel);
// };


// function Gift(data) {
//     this.id = data;
// };


// //LK accordion control
// function slideHide(){
//   $(".browsePane").on('click', '.accordion .giftHead', function () {
//         $(this).next(".pane").slideToggle(100).siblings(".pane:visible").slideUp(100);
//         $(".accordion").children(".current").removeClass("current");
//         $(this).toggleClass("current");
//         //console.log($(".accordion").children());
        
//     });
// };


// //LK category filter
// function categoryFilter(){
    
// };



// //LK not used currently, awaiting a server call
// function DataRetrieve (callback) {
//     $.getJSON("/gifts.json", function(data){ callback(data) });
//     var mappedTasks = $.map(callback, function(item) { return new Gift(item) });
//     return mappedTasks;
// };
