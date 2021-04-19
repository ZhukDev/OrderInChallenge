import React from "react";
import { List, Image, Header } from 'semantic-ui-react'
import MenuItem from './MenuItem'

const Restaurant = (props) => {
  const menuItemSelected = (itemId) => {
    props.onItemSelected(props.id, itemId)
  };
  return (
    <List.Item>
        <Image src={props.logoPath} size='tiny' verticalAlign='middle' />{' '}
        <List.Content>
          <List.Header>
            {props.name} - {props.suburb} - rated #{props.rank} overall
          </List.Header>
          {
            props.categories.map((x, i) => (
              <div>
                <List.Description key={i + x.name}>
                  {x.name}
                </List.Description>
                {x.menuItems.map((mi, j) => (
                  <List.List>
                    <MenuItem key={i + x.name + j} {...mi} onMenuItemSelected={menuItemSelected}/>
                  </List.List>
                ))}
              </div>
            ))
          }
          
        </List.Content>
    </List.Item>
  );
};

export default Restaurant;
