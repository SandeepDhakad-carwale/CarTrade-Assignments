import React from 'react'
import '../styleSheets/BudgetBtn.css'
import { useDispatch } from 'react-redux'
import { setBudget } from '../redux/actions/carDataActions.js'

const BudgetBtn = ({content, range,setStart,setEnd}) => {
    const dispatch=useDispatch()
    const start=range[0];
    const end=range[1];
  const handleClick=(e)=>{
    setStart(start)
    setEnd(end)
     dispatch(setBudget({start,end}))
  }
  return (
    <button className='btn' onClick={handleClick}>{content}</button>
  )
}

export default BudgetBtn