import React from "react";
import { Input } from 'semantic-ui-react'

const Search = (props) => {
  return (
    <Input value={props.search} onChange={(e) => props.onSearchChange(e)} icon='search' placeholder='Search...' />
  );
};

export default Search;
