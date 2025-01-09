
console.log("hello world")

document.getElementsByClassName("pass-icon")[0].addEventListener("click",function(){

    console.log("pass icon clicked")
    const password=document.getElementById("password")
    const passIcon=document.getElementsByClassName("pass-icon")[0]
    
    if(password.type=="text"){
        password.type="password";
        passIcon.src="./icons/open-eye.png"
     }
     else{
         password.type="text";
         passIcon.src="./icons/closed-eye.png"
     }
});


document.getElementsByClassName("repass-icon")[0].addEventListener("click",function(){
console.log("repassicon clicked")
const confirmPassword=document.getElementById("confirmPassword")
const repassIcon=document.getElementsByClassName("repass-icon")[0]

if(confirmPassword.type=="text"){
    confirmPassword.type="password";
    repassIcon.src="./icons/open-eye.png";
 }
 else{
    confirmPassword.type="text";
     repassIcon.src="./icons/closed-eye.png";
 }

});


// ------------------------------

    let username_valid=false;
    let email_valid=false;
    let password_valid=false;
    let confirmPassword_valid=false;

 const username=document.getElementById("username");

 username.addEventListener('change',()=>{
 const usermsg=document.getElementsByClassName("username-msg")[0];
 const userBorder=document.getElementsByClassName("userBorder")[0];


    const name_size=username.value.trim().length;
    if(name_size>=3 && name_size<=25 ){
        username_valid=true;
        userBorder.classList.remove('redBorder')
        userBorder.classList.add('greenBorder')
        usermsg.classList.remove('show')
    }
    else{
        username_valid=false;
        userBorder.classList.remove('greenBorder')
        userBorder.classList.add('redBorder')
        usermsg.classList.add('show');
    }
    

 })

 
 
 const email=document.getElementById("email");
 email.addEventListener('change',()=>{
 const emailmsg=document.getElementsByClassName("emailmsg")[0];
 const emailBorder=document.getElementsByClassName("emailBorder")[0];
 
  let b=false;
  const str=email.value;
  for(let i=0;i<str.length;i++){
    if(str[i]=='@'){
        b=true;
        break;
    }
  }
 if(b){
    email_valid=true;
    emailBorder.classList.remove('redBorder')
    emailBorder.classList.add('greenBorder')
    emailmsg.classList.remove('show')
 }
 else{
    email_valid=false;
        emailBorder.classList.remove('greenBorder')
        emailBorder.classList.add('redBorder')
        emailmsg.classList.add('show');
 }
    
 })


 
 
 const  password=document.getElementById("password");
 password.addEventListener('change',()=>{
 const passmsg=document.getElementsByClassName("passmsg")[0];
 const passBorder=document.getElementsByClassName("passBorder")[0];

 const pass=password.value.trim();
 console.log("pass->",pass)
 
 if(pass.length>=8){

    let uppercase=false;
    let lowercase=false;
    let number=false;
    let special=false;

     for(let j=0;j<pass.length;j++){
        const i=pass[j];
         if(i>='a' && i<='z') lowercase=true;
         else if(i>='A' && i<='Z') uppercase=true;
          else if(i>='0' && i<='9') number=true;
          else if(i=='!' || i=='@' || i=='#' || i=='$' || i=='%' || i=='^' || i=='&' || i=='*')
            special=true;

     }

     if(uppercase && lowercase && number && special){
        password_valid=true;
        passBorder.classList.remove('redBorder');
        passBorder.classList.add('greenBorder');
        passmsg.classList.remove('show')
     }
     else{
        password_valid=false;
        passBorder.classList.remove('greenBorder')
        passBorder.classList.add('redBorder')
        passmsg.classList.add('show');
     }

 }
 else{
    password_valid=false;
    passBorder.classList.remove('greenBorder')
    passBorder.classList.add('redBorder')
    passmsg.classList.add('show');
 }
})



 const confirmPassword=document.getElementById("confirmPassword");
 confirmPassword.addEventListener('change',()=>{
 const cpassBorder=document.getElementsByClassName('cpassBorder')[0];
 const cpassmsg=document.getElementsByClassName('cpassmsg')[0];

 const confirmPass=confirmPassword.value.trim();

 
 if(password.value.trim()==confirmPass){
    confirmPassword_valid=true;
    cpassBorder.classList.remove('redBorder');
        cpassBorder.classList.add('greenBorder');
        cpassmsg.classList.remove('show')
 }
 else{
    confirmPassword_valid=false;
    cpassBorder.classList.remove('greenBorder')
    cpassBorder.classList.add('redBorder')
    cpassmsg.classList.add('show');
 }

 })




 const form=document.getElementsByClassName("form-container")[0]

 form.addEventListener("submit",function(e){
    // console.log("clicked on submit button")
    e.preventDefault();


    if(username_valid && email_valid && password_valid && confirmPassword_valid){
        alert("Your are signed up");
        form .reset();
    }
    else {
        alert("Please read the instruction and fill form correctly...")
    }

 })





