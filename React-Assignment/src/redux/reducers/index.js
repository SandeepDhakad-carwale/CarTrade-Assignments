import { combineReducers } from "redux";
import carDataReducer from "./carDataReducer.js";

const rootReducer = combineReducers({
  carData: carDataReducer, 
});

export default rootReducer;
