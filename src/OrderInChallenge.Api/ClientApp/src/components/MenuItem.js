import React from "react";
import { List, Checkbox } from 'semantic-ui-react'

const MenuItem = (props) => {
  return (
    <List.Item>
        <List.Content>
          <List.Header>
            <Checkbox onChange={() => props.onMenuItemSelected(props.id)} label={{ children: `${props.name} - R${props.price}` }} />
          </List.Header>          
        </List.Content>
    </List.Item>
  );
};

export default MenuItem;
