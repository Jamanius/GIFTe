function Gift() {
    this.id = null;
    this.title = null;
    this.description = null;
    this.comments = null;
    this.image = null;
};

Gift.prototype = {
  update: function() {
    console.log('Update Gift');

  },

  delete: function() {
    console.log('Delete Gift');

  }
};
