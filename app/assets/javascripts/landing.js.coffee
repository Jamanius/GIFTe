# Place all the behaviors and hooks related to the matching controller here.
# All this logic will automatically be available in application.js.
# You can use CoffeeScript in this file: http://coffeescript.org/

$ ->
  $('.status').hover (event) ->
    #console.log("hover triggered")
    $(this).toggleClass("hover");

    $(".welcome-notice").hide().show("slow");
