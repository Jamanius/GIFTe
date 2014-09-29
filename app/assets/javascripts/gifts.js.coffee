# Place all the behaviors and hooks related to the matching controller here.
# All this logic will automatically be available in application.js.
# You can use CoffeeScript in this file: http://coffeescript.org/


# Should be consitat with the project and use either all JS
# or all Coffeescript
$ ->
  $('.gift').hover (event) ->
    console.log("hover triggered")
    $(this).toggleClass("hover")
