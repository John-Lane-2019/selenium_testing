//validates form data
function validateInput(){
  
  var sellerName = document.getElementById('seller_name').value;
  var address = document.getElementById('address').value;
  var city = document.getElementById('city').value;
  var phone = document.getElementById('phone').value;
  var email = document.getElementById('email').value;
  var make = document.getElementById('make').value;
  var model = document.getElementById('model').value;
  var year = document.getElementById('year').value;
  //regexes for email and phone number
  const emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  const phoneRegex = /^[(]{0,1}[0-9]{3}[)]{0,1}[-\s\.]{0,1}[0-9]{3}[-\s\.]{0,1}[0-9]{4}$/

  if(sellerName === ""){
    alert('Please complete all fields');
  }
  
  else if(address === ""){
    alert('Please complete all fields');
  }
  
  else if(city === ""){
    alert('Please complete all fields');
  }
  
  else if(phone === ""){
    alert('Please complete all fields');
  }

  else if (!phone.match(phoneRegex)){
    alert('Acceptable phone number formats: ' + 
    '(123) 456-7890' + '  ' + '123-456-7890' + ' ' + '123.456.7890' + ' ' + '1234567890');
  }
  
  else if(email === ""){
    alert('Please complete all fields');
  }

  else if(!email.match(emailRegex)){
    alert('Invalid email format');
  }

  else if(make === ""){
    alert('Please complete all fields');
  }
  
  else if(model === ""){
    alert('Please complete all fields');
  }
  
  else if(year === ""){
    alert('Please complete all fields');
  }

  else if(parseInt(year)< 1900 || parseInt(year)>2020){
    alert('Please enter a year not less than 1900 and not greater than 2020');
  }

  else{
    document.getElementById('form').reset();
    saveInputs(sellerName,address,city,phone,email,make,model,year);
  }

}
//saves inputs to local storage
function saveInputs(sellerName,address,city,phone,email,make,model,year){
  //create input object
  var input = {
    sellerName: sellerName,
    address:address,
    city:city,
    phone: phone,
    email: email,
    make: make,
    model: model,
    year: year
  }

  localStorage.setItem(sellerName, JSON.stringify(input));
  outputStoredObjects(sellerName);
}
//output stored objects to GUI
function outputStoredObjects(sellerName){

  var retrievedObject = localStorage.getItem(sellerName);

  var output = JSON.parse(retrievedObject);

  var contact = `Name: ${output.sellerName}, 
  Address: ${output.address}, 
  City: ${output.city}, 
  Phone: ${output.phone}, 
  Email: ${output.email}, 
  Make: ${output.make}, 
  Model: ${output.model}
  Year: ${output.year}`;

  var ulContact = document.getElementById("contact_list");
  var contactLi = document.createElement("li");
  contactLi.appendChild(document.createTextNode(contact));
  ulContact.appendChild(contactLi);

  var a = document.createElement("a");
  var linksList = document.getElementById("links_list");
  var newItem = document.createElement("li");

  a.textContent = `http://www.jdpower.com/cars/${output.make}/${output.model}/${output.year}`;
  a.setAttribute('href',`http://www.jdpower.com/cars/${output.make}/${output.model}/${output.year}`);
  newItem.appendChild(a);
  linksList.appendChild(newItem);
  
}
//output stored objects to GUI
function displaySavedObjects(){

  var retrievedObject;
  for(var i = 0; i <localStorage.length ; i++){
    retrievedObject = localStorage.getItem(localStorage.key(i));
    var output = JSON.parse(retrievedObject); 

    var contact = `Name: ${output.sellerName}, 
  Address: ${output.address}, 
  City: ${output.city}, 
  Phone: ${output.phone}, 
  Email: ${output.email}, 
  Make: ${output.make}, 
  Model: ${output.model}
  Year: ${output.year}`;

  var ulContact = document.getElementById("saved_objects");
  var contactLi = document.createElement("li");
  contactLi.appendChild(document.createTextNode(contact));
  ulContact.appendChild(contactLi); 

  }
  
}

