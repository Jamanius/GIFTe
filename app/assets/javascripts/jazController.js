function Controller() {
  this.view = null;
  this.gifts = [];
};

Controller.prototype = {

  start: function(){
    this.view = new View();
    this.getGifts();
    // $(this.view.addGiftButtonSelector).on("click", this.setupNewGift.bind(this));
  },

  getGifts: function() {
    //ajax gets data. "var self = this" needed for ajax requests
    var self = this;
    var ajaxRequest = $.ajax({
        url: "/gifts.json",
        type: "GET",
        //'for' loop extracts gift data from the JSON & creates gift objects
        // consider moving this anonymous function into a named function
        success: function(data) {
          // don't commit debugging statements
          console.log(data);
          self.gifts = [];
          for (var i=0; i<data.length; i++) {
            // console.log(data[i].title);
            //new gift is created with full parameters
            var gift = new Gift();
            gift.id = data[i].id;
            gift.title = data[i].title;
            gift.image = data[i].image;

            self.gifts.push(gift);
          }
          self.view.refreshGiftList(self.gifts);
          // assigning click action to 'a' tags(all gift names)
          $(self.view.giftListSelector).find('a').on("click", self.showGiftDetails.bind(self));
        },
        error: function(data) {
          console.log("ERROR: " + data);
          window.location.replace('/')
        }
    });
  },

  showGiftDetails: function(e) {
    e.preventDefault();
    var el = $(e.target);
    var gift = this.findGiftById( el.data('gift-id') );
    console.log(gift);

    // use a handlebars.js template for the gift details form
    var source = $(this.view.giftDetailsTemplateSelector).html();
    var template = Handlebars.compile(source);
    var context = {
      id: gift.id,
      title: gift.title,
      image: gift.image,
    };

    var html = template(context);
    // send the html from the template to the view
    this.view.showGiftDetails(html);

    // don't commit commented out code
    // use git and Github to refer to old code instead.
    // bind events for the save and delete buttons
    // $(this.view.saveButtonSelector).on("click", this.updateGiftDetails.bind(this));
    // $(this.view.deleteButtonSelector).on("click", this.deleteGift.bind(this));
    // $(this.view.addNoteButtonSelector).on("click", this.addNote.bind(this));

    // this.getGiftNotes(gift.id);
  },

//   getGiftNotes: function(gift_id) {
//     // load the gift notes using ajax
//     var self = this;
//     var ajaxRequest = $.ajax({
//       url: "/gifts/" + gift_id + "/notes",
//       type: "GET",
//       //'for' loop extracts gift data from the JSON & creates gift objects
//       success: function(data) {
//         console.log('success loading notes');
//         // console.log(data);
//         $(self.view.giftNotesListSelector).html(data);
//         self.view.reverseNoteOrder();
//       },
//       error: function(data) {
//         console.log('error loading notes');
//         console.log(data);
//       }
//     });

//   },

//   updateGiftDetails: function(e) {
//     e.preventDefault();
//     var detail = {
//       name: $(this.view.giftDetailsFormSelector).find('#name').val(),
//       email: $(this.view.giftDetailsFormSelector).find('#email').val(),
//       phone_number: $(this.view.giftDetailsFormSelector).find('#phone_number').val()
//     }
//     console.log('updateGiftDetails');
//     var self = this;
//     var ajaxRequest = $.ajax({
//       url: "/gifts/" + $(this.view.giftDetailsFormSelector).find('#id').val(),
//       type: "PUT",
//       data: { "gift": detail },
//       success: function(data) {
//         console.log("Gift updated.");
//         self.getGifts();
//       },
//       error: function(data) {
//         console.log("Error updating gift.");
//       }
//     });
//   },

//     //saves to database
//   addGift: function(e) {
//     e.preventDefault();
//     console.log('addGift');
//     var detail = {
//       name: $(this.view.giftDetailsFormSelector).find('#name').val(),
//       email: $(this.view.giftDetailsFormSelector).find('#email').val(),
//       phone_number: $(this.view.giftDetailsFormSelector).find('#phone_number').val()
//     }
//     var self = this;
//     var ajaxRequest = $.ajax({
//       url: "/gifts",
//       type: "POST",
//       data: { "gift": detail },
//       success: function(data) {
//         console.log("Gift created.");
//         self.getGifts();
//         self.view.showEmptyGiftDetails();
//       },
//       error: function(data) {
//         console.log("Error creating gift.");
//       }
//     });
//   },



//   //blank form
//   setupNewGift: function(e) {
//     e.preventDefault();
//     console.log("setupNewGift");
//     var el = $(e.target);
//     var gift = new Gift();

//     // use a handlebars.js template for the gift details form
//     var source = $(this.view.giftDetailsTemplateSelector).html();
//     var template = Handlebars.compile(source);
//     // is an empty object for the user to create a new client object with
//     var context = {};

//     var html = template(context);
//     // send the html from the template to the view
//     this.view.showGiftDetails(html);

//     // bind event for the save button
//     $(this.view.saveButtonSelector).on("click", this.addGift.bind(this));

//     // hide these things that we don't need for a new gift
//     $(this.view.deleteButtonSelector).hide();
//     $(this.view.giftNotesSectionSelector).hide();

//   },

//   deleteGift: function(e) {
//     // e.preventDefault();
//     // console.log('deleteGift');
//     var self = this;
//     var gift_id = $(this.view.giftDetailsFormSelector).find('#id').val();
//     var ajaxRequest = $.ajax({
//       url: "/gifts/" + gift_id,
//       type: "DELETE",
//       success: function(data) {
//         console.log("Gift deleted.");
//         self.getGifts();
//         self.view.showEmptyGiftDetails();
//       },
//       error: function(data) {
//         console.log("Error deleting gift.");
//       }
//     });
//   },

//   addNote: function(e) {
//     e.preventDefault();
//     console.log("add note");
//     var self = this;
//     var gift_id = $(this.view.giftDetailsFormSelector).find('#id').val();
//     var note_content = $(this.view.giftNotesFormSelector).find('#note').val();
//     if (note_content != '') {
//       var ajaxRequest = $.ajax({
//         url: "/gifts/" + gift_id + "/notes",
//         type: "POST",
//         data: { "note": { "content": note_content } },
//         success: function(data) {
//           console.log("Gift note created");
//           self.getGiftNotes(gift_id);
//         },
//         error: function(data) {
//           console.log("Error creating gift note: "+ note_content);
//         }
//       });
//       // after adding the note to the database we clear the textarea value ready for another note
//       $(this.view.giftNotesFormSelector).find('#note').val('');
//     }
//   },

  findGiftById: function(id) {
    for (var i=0; i<this.gifts.length; i++) {
      if (this.gifts[i].id == id) {
        return this.gifts[i];
      }
    }
  },

//   sortGifts: function(sort_by) {
//     switch(sort_by) {
//       case "first_name":
//       // console.log("sort by first");
//         this.gifts.sort(function(a,b) {
//           if (a.first_name() < b.first_name()) return -1;
//           if (a.first_name() > b.first_name()) return 1;
//           return 0;
//         });
//         break;
//       case "last_name":
//         this.gifts.sort(function(a,b) {
//           if (a.last_name() < b.last_name()) return -1;
//           if (a.last_name() > b.last_name()) return 1;
//           return 0;
//         });
//         break;
//     }
//   }

};

