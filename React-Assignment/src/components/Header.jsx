import React from 'react'
import '../styleSheets/Header.css'


const Header = () => {
  console.log("Header re-renders.....")
  
  return (
    <div className='header' onClick={()=>{updateFuel()}}>Header</div>
  )
}

export default Header