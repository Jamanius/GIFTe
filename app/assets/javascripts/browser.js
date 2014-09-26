// Overall viewmodel for this screen, along with initial state
function GiftListViewModel() {
    //data
    var self = this;
    self.gifts = ko.observableArray([]);


//operations
    // self.addGift = function(){
        
    // };
    self.gifts(dummyData());

};


//LK not used currently, awaiting a server call
// function DataRetrieve (callback){
// $.getJSON("http://api.ihackernews.com/newcomments", function(data){callback(data)});
// var mappedTasks = $.map(callback, function(item) { return new Gift(item) });
// return mappedTasks;
// };

function Gift(data) {
    this.id = data;
};

//LK wait for the doc to know about knockout
$( document ).ready(function() {
    ko.applyBindings(new GiftListViewModel());
    slideHide();
    $(".pane").hide();
});


//LK create array to test ko
function dummyData(){
var dummyList = [];
for (var i = 0; i <= 4; i++) {
    dummyList.push(new Gift(i));
};
return dummyList;
};


//LK accordion control
function slideHide(){
  $(".accordion .giftHead").click(function () {
        $(this).next(".pane").slideToggle(100).siblings(".pane:visible").slideUp(100);
        $(this).toggleClass("current");
        $(this).siblings("h3").removeClass("current");
    });
};



