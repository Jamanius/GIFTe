function View() {
  this.giftListSelector = "#gift-list";
  this.giftDetailsSelector = "#gift-details";

  this.giftListItemTemplateSelector = "#gift-list-item-template";
  this.giftDetailsTemplateSelector = "#gift-details-template";

  this.initialize();
}

View.prototype = {

	initialize: function() {
	
  },

	refreshGiftList: function(gifts) {
	    // console.log("updateCustomerList");
	    $(this.giftListSelector).html('');
	    // received data from controller, loops through then uses jQuery to append each customers name inside HTML tags 
	    // handlebars.js "precompilation", below two variables required to compile before "execution"
	    var source   = $(this.giftListItemTemplateSelector).html();
		var template = Handlebars.compile(source);
	    for (var i=0; i<gifts.length; i++) {
	    	// $(this.customerListSelector).append('<li><a href="#" data-customer-id='+customers[i].id+'>' + customers[i].full_name() + '</a></li>');
	    	// replaced above hardcoded code containing HTML with handlebars.js below:
	    	// Handlebars.js "execution": var context/html - mandatory handlebars.js naming convention. context looks like a Ruby hash but in JS is an object
	    	var context = {
	    		id:    gifts[i].id,
	    		title: gifts[i].title, 
	    		image: gifts[i].image
	    	};
			var html = template(context);
			$(this.giftListSelector).append(html);
	    }
  },

  showGiftDetails: function(html) {
  	$(this.giftDetailsSelector).html(html);
  },

  // reverseNoteOrder: function() {
  // 	console.log("reversing notes");
  // 	// finds class of .notes inside the customers notes, reverses with prepend and each
  //   var notes = $('.notes', this.customerNotesListSelector);
  //   notes.children().each(function(i,el) {
  //   	// console.log(el);
  //   	notes.prepend(el);
  //   });
  // }
};

